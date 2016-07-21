namespace Weather.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContextCity : DbContext
    {
        // Контекст настроен для использования строки подключения "ContextCity" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Weather.Models.ContextCity" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ContextCity" 
        // в файле конфигурации приложения.
        public ContextCity()
            : base("name=ContextCity")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
    }

    //    <add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=CityDB;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnet-Weather-20160707092653.mdf" />
    //(LocalDb)\v11.0

}