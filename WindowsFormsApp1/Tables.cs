using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace WindowsFormsApp1
{
    [Table(Name = "Service")]
    public class Servicee
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public decimal Cost { get; set; }
        [Column]
        public int DurationInSeconds { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public double Discount { get; set; }
        [Column]
        public string MainImagePath { get; set; }

    }
    [Table(Name = "client")]
    public class client
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public string Patronymic { get; set; }
        [Column]
        public DateTime Birthday { get; set; }
        [Column]
        public DateTime RegistrationDate { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public char GenderCode { get; set; }
        [Column]
        public string PhotoPath { get; set; }

    }
    [Table(Name = "ClientService")]
    public class clientService
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }
        [Column]
        public int ClientID { get; set; }
        [Column]
        public int ServiceID { get; set; }
        [Column]
        public DateTime StartTime { get; set; }
        [Column]
        public string Comment { get; set; }
    }
}
//create view v2 as
//SELECT [ID], concat([Title], ' ' ,[Cost], ' ' ,[DurationInSeconds]) as ser
//,[Description]
//,[Discount]
//,[MainImagePath]
//FROM[abd_12].[dbo].[Service]
