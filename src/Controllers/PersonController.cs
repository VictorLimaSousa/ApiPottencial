using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{  

    private DataBaseContext _repository { get; set; }
    public PersonController(DataBaseContext repository)
    {
        this._repository = repository;
    }
    
    [HttpGet]
    public ActionResult< List<Person>> Get()
    {
        //Person pessoa = new Person("Victor Lima", 35, "123456");
        //Contract NovoContrato = new Contract("Abc123", 50.40);
        //pessoa.Constratos.Add(NovoContrato);

       var resultado = _repository.Pessoas.Include(p => p.Constratos).ToList();

       if(!resultado.Any()){
        return NoContent();
       }else{

             return Ok(resultado) ;
       }
       

    }
    [HttpPost]
    public Person Post(Person pessoa)
    {
        _repository.Pessoas.Add(pessoa);
        _repository.SaveChanges();
        return pessoa;
    }

    [HttpPut ("{id}")]
    public ActionResult<object> Put([FromRoute]int id, [FromBody]Person pessoa)
    {

        try
        {
             _repository.Pessoas.Update(pessoa);
             _repository.SaveChanges();
            
        }
        catch (System.Exception)
        {
            
            return BadRequest(new{ msg ="Houve erra de envio de tualização do "+ id, Status = HttpStatusCode.OK});
        }
       
        
        return (new{ msg ="Id "+ id + " Atualizado", Status = HttpStatusCode.OK});
    }

    [HttpDelete ("{id}")]
    public ActionResult< object> Delete([FromRoute]int id)
    {
        var resultado = _repository.Pessoas.SingleOrDefault( e => e.Id == id);

        if(resultado is null)
        {
            return BadRequest( new{ msg ="Conteudo Inexistente, solictação invalida", HttpStatusCode.BadRequest});
           
        }
        _repository.Pessoas.Remove(resultado);
        _repository.SaveChanges();

         return Ok(new{ msg ="Dados do Id " + id + " deletados ", HttpStatusCode.OK}); 
    }

}