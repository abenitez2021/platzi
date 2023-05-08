using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void OnModelCreating (ModelBuilder modelBuilder)

    {
        List<Categoria>categoriasInit= new List<Categoria>();
        categoriasInit.Add(new Categoria() {CategoriaId=Guid.Parse("c3345a24-b7fd-4a22-859d-520f99f4eafb"), Nombre="actividades pendientes",Peso=20, volumen=10 });
        categoriasInit.Add(new Categoria() {CategoriaId=Guid.Parse("c3345a24-b7fd-4a22-859d-520f99f4ea02"), Nombre="actividades personales",Peso=20, volumen=10 });

        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);
            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=>p.Descripcion).IsRequired(false);
            categoria.Property(p=>p.Peso);
             categoria.Property(p=>p.volumen);
             categoria.HasData(categoriasInit);
        });
        
        List<Tarea>TareasInit = new List<Tarea>();
        TareasInit.Add(new Tarea(){TareaId=Guid.Parse("c3345a24-b7fd-4a22-859d-520f99f4ea03"), CategoriaID=Guid.Parse("c3345a24-b7fd-4a22-859d-520f99f4eafb"), PrioridadTarea=Prioridad.Media, Titulo="Pago de servicios",FechaCreacion=DateTime.Now});
        TareasInit.Add(new Tarea(){TareaId=Guid.Parse("c3345a24-b7fd-4a22-859d-520f99f4ea04"), CategoriaID=Guid.Parse("c3345a24-b7fd-4a22-859d-520f99f4ea02"), PrioridadTarea=Prioridad.Baja, Titulo="terminar mi serie",FechaCreacion=DateTime.Now});
        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaID);
            tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=>p.Descripcion).IsRequired(false);
            tarea.Property(p=>p.PrioridadTarea);
            tarea.Property(p=>p.FechaCreacion);
            tarea.Ignore(p=>p.Resumen);
            tarea.HasData(TareasInit);

        }
        );
    }
}