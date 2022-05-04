using Microsoft.AspNetCore.Mvc;
using dotnet_c_.Model;
using dotnet_c_.Repository;
namespace dotnet_c_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskControllers : ControllerBase
    {
        private readonly InterfaceTasksRepo _repo;
        public TaskControllers(InterfaceTasksRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get(){
            var tasks = await _repo.FindTasks();
            return tasks.Any() ? Ok(tasks) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var tasks = await _repo.FindTasks(id);
            return tasks != null ? Ok(tasks) : NotFound("task not found");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tasks tasks){
            _repo.AddTask(tasks);
            return await _repo.SaveChangesAsync() ? Ok("success") : BadRequest("not saved");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tasks tasks){
            var taskDB = await _repo.FindTasks(id);
            if(taskDB == null) return NotFound("task not found");

            taskDB.Title = tasks.Title ?? taskDB.Title;
            taskDB.Description = tasks.Description ?? taskDB.Description;

            _repo.UpdateTask(taskDB);

            return await _repo.SaveChangesAsync() ? Ok("success") : BadRequest("not updated");

        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Tasks tasks){
            var taskDB = await _repo.FindTasks(id);
            if(taskDB == null) return NotFound("task not found");

            _repo.DeleteTask(taskDB);

            return await _repo.SaveChangesAsync() ? Ok("success") : BadRequest("not updated");

        }
    }
}