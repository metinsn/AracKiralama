namespace AracKiralama.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class KiraDBContext : DbContext
    {
        public KiraDBContext()
            : base("name=KiraDB")
        {
        }
       
        public virtual DbSet<Kira> Kira { get; set; }
        public virtual DbSet<AracMarka> AracMarka { get; set; }
        public virtual DbSet<AracModel> AracModel { get; set; }
        public virtual DbSet<Arac> Arac { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
    }
}