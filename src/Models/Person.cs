using System.Collections.Generic;

namespace src.Models;

public class Person 
{
    public Person()
    {
        this.Nome = "Templeite";
        this.Idade = 0;
        this.status = true;
        this.Constratos = new List<Contract>();
    }
    public Person(string Nome, int Idade,string Cpf)
    {
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf  = Cpf;
        this.status = true;
        this.Constratos = new List<Contract>();
    }

    public int Id { get; set; }
    public String Nome { get; set; }

    public int Idade { get; set; }

    public string Cpf { get; set; }

    public bool status { get; set; }

    public List<Contract>  Constratos { get; set; }

    
}