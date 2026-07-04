using LibrarySystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Contracts
{
    public interface IBorrowable
    {
        bool IAvailable();
        void Borrow(Member member ,int LonDay =14);
        decimal Return();
    }
}
