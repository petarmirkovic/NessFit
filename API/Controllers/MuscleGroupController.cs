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
    public class MuscleGroupController : ControllerBase
    {
        private readonly IMuscleGroupRepository _muscleGroupRepository;

    public MuscleGroupController(IMuscleGroupRepository muscleGroupRepository)
    {
        _muscleGroupRepository = muscleGroupRepository;
    }

    [HttpGet("{id}")]
    public ActionResult<MuscleGroup> GetById(int id)
    {
        var muscleGroup = _muscleGroupRepository.GetById(id);
        if (muscleGroup == null)
        {
            return NotFound();
        }
        return muscleGroup;
    }

    [HttpPost]
    public ActionResult<MuscleGroup> Create(MuscleGroup muscleGroup)
    {
        _muscleGroupRepository.Add(muscleGroup);
        return CreatedAtAction(nameof(GetById), new { id = muscleGroup.MuscleGroupId }, muscleGroup);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, MuscleGroup muscleGroup)
    {
        if (id != muscleGroup.MuscleGroupId)
        {
            return BadRequest();
        }
        if (!_muscleGroupRepository.Exists(id))
        {
            return NotFound();
        }
        _muscleGroupRepository.Update(muscleGroup);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var muscleGroup = _muscleGroupRepository.GetById(id);
        if (muscleGroup == null)
        {
            return NotFound();
        }
        _muscleGroupRepository.Delete(muscleGroup);
        return NoContent();
    }

    // [HttpGet("{muscleGroupName}/exercises")]
    // public ActionResult<IEnumerable<Exercise>> GetExercisesByMuscleGroupName(string muscleGroupName)
    // {
    //     var exercises = _muscleGroupRepository.GetExercisesByMuscleGroupName(muscleGroupName);
    //     return exercises.ToList();
    // } 


    //------------To be made-----------
    }
}