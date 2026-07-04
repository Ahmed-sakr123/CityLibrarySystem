using LibrarySystem.Contracts;
using LibrarySystem.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Entities
{
    public class BookCopy:IDisplayable,IBorrowable
    {
        public string CopyId { get; private set; } = null;
        public Book Book { get; private set; } = null;
        public CopyCondition Condition { get; private set; }
        public CopyStatus Status { get; private set; }
        public BorrowTransaction? ActiveBorrowTransaction { get; set; }

        public BookCopy(string copyId, CopyCondition condition, CopyStatus copyStatus, Book book)
        {
            CopyId = copyId;
            Condition = condition;
            Status = copyStatus;
            Book = book;
        }

        public void Borrow(Member member, int loanDays = 14)
        {
            if (!IAvailable())
                throw new InvalidOperationException($"Copy {CopyId} is not available (status = {Status})");

            Status = CopyStatus.Borrowed;

            ActiveBorrowTransaction = new BorrowTransaction(member, this, loanDays);

            member.AddBorrowTransaction(ActiveBorrowTransaction);
        }



        public bool IAvailable() => Status == CopyStatus.Available;
        public decimal Return()
        {
            if (Status is not CopyStatus.Borrowed)
                throw new InvalidOperationException("Copy is not currently borrowed.");

            ActiveBorrowTransaction!.MarkReturned(DateOnly.FromDateTime(DateTime.Today));

            decimal fine = ActiveBorrowTransaction.CalculateFine();

            Status = CopyStatus.Available;

            ActiveBorrowTransaction = null;

            return fine;
        }


        public string DisplayInformations() => $"Copy [{CopyId}] - {Book.Title} | Condition: {Condition} | {Status}"; 


    }
}
