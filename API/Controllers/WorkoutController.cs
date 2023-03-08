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
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutRepository _workoutRepository;

    public WorkoutController(IWorkoutRepository workoutRepository)
    {
        _workoutRepository = workoutRepository;
    }

    [HttpGet("{id}")]
    public ActionResult<Workout> GetById(int id)
    {
        var workout = _workoutRepository.GetById(id);
        if (workout == null)
        {
            return NotFound();
        }
        return workout;
    }

    [HttpPost]
    public ActionResult<Workout> Create(Workout workout)
    {
        _workoutRepository.Add(workout);
        return CreatedAtAction(nameof(GetById), new { id = workout.WorkoutId }, workout);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Workout workout)
    {
        if (id != workout.WorkoutId)
        {
            return BadRequest();
        }
        if (!_workoutRepository.Exists(id))
        {
            return NotFound();
        }
        _workoutRepository.Update(workout);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var workout = _workoutRepository.GetById(id);
        if (workout == null)
        {
            return NotFound();
        }
        _workoutRepository.Delete(workout);
        return NoContent();
    }

    [HttpGet("{userId}/workouts")]
    public ActionResult<IEnumerable<Workout>> GetByUserId(int userId)
    {
        var workouts = _workoutRepository.GetByUserId(userId);
        return workouts.ToList();
    }
    }
}