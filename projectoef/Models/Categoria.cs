using System.ComponentModel.DataAnnotations;

namespace proyectoef.Models;
public class Categoria {
    [Key]
    public Guid CategoriaId{set;get;}
    
    [Required]
    [MaxLength(150)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public virtual ICollection<Tarea> Tareas{get;set;}

}