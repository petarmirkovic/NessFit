using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseController(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    [HttpGet("{id}")]
    public ActionResult<Exercise> GetById(int id)
    {
        var exercise = _exerciseRepository.GetById(id);
        if (exercise == null)
        {
            return NotFound();
        }
        return exercise;
    }

    [HttpPost]
    public ActionResult<Exercise> Create(Exercise exercise)
    {
        _exerciseRepository.Add(exercise);
        return CreatedAtAction(nameof(GetById), new { id = exercise.ExerciseId }, exercise);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Exercise exercise)
    {
        if (id != exercise.ExerciseId)
        {
            return BadRequest();
        }
        if (!_exerciseRepository.Exists(id))
        {
            return NotFound();
        }
        _exerciseRepository.Update(exercise);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var exercise = _exerciseRepository.GetById(id);
        if (exercise == null)
        {
            return NotFound();
        }
        _exerciseRepository.Delete(exercise);
        return NoContent();
    }
}

}