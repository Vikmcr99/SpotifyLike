using StreamingApp.Domain.Transaction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingApp.Domain.Transaction
{
    public class Card
    {
        private const int TRANSACTION_TIME_INTERVAL = -2;
        private const int TRANSACTION_MERCHANT_REPEAT = 1;
        public Guid Id { get; set; }
        public Boolean Active { get; set; }
        public Decimal Limit { get; set; }
        public String Number { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void CreateTransaction(string merchant, decimal value, string description)
        {
            CardException validationErrors = new CardException();

            this.IsCardActive(validationErrors);

            Transaction transaction = new Transaction();
            transaction.Merchant = merchant;
            transaction.Value = value;
            transaction.Description = description;
            transaction.Date = DateTime.Now;

            this.VerifyLimit(transaction, validationErrors);

            this.ValidateTransaction(transaction, validationErrors);

            validationErrors.ValidateAndThrow();

            transaction.Id = Guid.NewGuid();
            this.Limit = this.Limit - transaction.Value;
            this.Transactions.Add(transaction);
        }

        private void IsCardActive(CardException exception)
        {
            if (this.Active == false)
                exception.AddError(new Core.Exceptions.BusinessValidation()
                {
                    ErrorDescription = "No active Card",
                    ErrorName = nameof(Card)
                });
        }

        private void VerifyLimit(Transaction transaction, CardException exception)
        {
            if (transaction.Value > this.Limit)
                exception.AddError(new Core.Exceptions.BusinessValidation()
                {
                    ErrorDescription = "Card does not has suffiient limit",
                    ErrorName = nameof(Card)
                });
        }

        private void ValidateTransaction(Transaction transaction, CardException exception)
        {
            var lastTransactions = this.Transactions.Where
                (x => x.Date >= DateTime.Now.AddMinutes(TRANSACTION_TIME_INTERVAL));

            if (lastTransactions?.Count() > 3)
                exception.AddError(new Core.Exceptions.BusinessValidation()
                {
                    ErrorDescription = "Cards has exceeded the number of 3 transactions ",
                    ErrorName = nameof(Card)
                });

            var repeatedTransaction = lastTransactions.Where
                (x => x.Merchant.ToUpper() == transaction.Merchant.ToUpper() && x.Value == transaction.Value)
                .Count() == TRANSACTION_MERCHANT_REPEAT;

            if (repeatedTransaction)
                exception.AddError(new Core.Exceptions.BusinessValidation() 
                { ErrorDescription = "Duplicate Transaction", 
                  ErrorName = nameof(Card) 
                });


        }


    }
}

