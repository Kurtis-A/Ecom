using Ecom.Data.Model.Base;
using System;

namespace Ecom.Data.Model
{
    public class Rota : ISoftDeleteEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Archived { get; set; }
    }
}
