namespace Games.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public int id { get; set; }

        public int? customer_id { get; set; }

        public int? game_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int? quantity { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Gamer Gamer { get; set; }
    }
}
