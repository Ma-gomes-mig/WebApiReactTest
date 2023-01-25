using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunosApi.Models
{
    //Poderia colocar este DataAnnotation para informar que este model é uma tabela no banco de dados,
    //porém já informei na pasta context.
    //[Table("Alunos")]
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(80)]
        public string StudentName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
