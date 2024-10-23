using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }  // Identificador único de la transacción

        public decimal TotalAmount { get; set; }  // Total de la transacción

        public DateTime Date { get; set; }  // Fecha de la transacción

        public string Seller { get; set; }  // Vendedor que realizó la transacción

        // Relación con los artículos vendidos en la transacción
        public ICollection<TransactionDetail> SoldItems { get; set; }

        public Transaction()
        {
            SoldItems = new List<TransactionDetail>();  // Inicialización de la colección
        }

        public Transaction(decimal totalAmount, DateTime date, string seller, ICollection<TransactionDetail> soldItems)
        {
            TotalAmount = totalAmount;
            Date = date;
            Seller = seller;
            SoldItems = soldItems ?? new List<TransactionDetail>();
        }
    }
}
