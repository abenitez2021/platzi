using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace proyectoef.Models;
public class Categoria {
    //[Key]
    public Guid CategoriaId{set;get;}
    
   // [Required]
    //[MaxLength(150)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public int Peso{get; set;}
    public int volumen{get; set;}

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas{get;set;}

}