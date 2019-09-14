using System;
using System.Collections.Generic;
using System.Text;

namespace APIOrientacao.Data
{
    public class Curso
    {
        public Curso()
        {
            //Categoria
            Alunos = new HashSet<Aluno>();
        }
        public int IdCurso { get; set; }
        public string Nome { get; set; }

        public ICollection<Aluno> Alunos { get; set; }
    }
}
