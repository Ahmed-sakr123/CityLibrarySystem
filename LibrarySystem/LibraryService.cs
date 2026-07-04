using LibrarySystem.Entities;
using LibrarySystem.Services;

namespace LibrarySystem
{

    public class LibraryService(LibraryBranch branch, DisplayService display)
    {
        private readonly LibraryBranch _branch = branch;
        private readonly DisplayService _display = display;

        public void HandleBorrow()
        {
            string memberId = ThemeHelper.Prompt("Member ID").Normalize();
            Member member = _branch.FindMemberById(memberId);

            _display.ShowAvailableCopies(_branch);

            string copyId = ThemeHelper.Prompt("Copy ID to borrow").Normalize();
            BookCopy copy = _branch.FindCopyByCopyId(copyId);

            copy.Borrow(member);

            _display.ShowBorrowSuccess(copy, member);
        }

        public void HandleReturn()
        {
            string copyId = ThemeHelper.Prompt("Copy ID to return").Normalize();
            BookCopy copy = _branch.FindCopyByCopyId(copyId);

            decimal fine = copy.Return();
            _display.ShowReturnSuccess(copy, fine);
        }

        public void HandleHistory()
        {
            string memberId = ThemeHelper.Prompt("Member ID").Normalize();
            Member member = _branch.FindMemberById(memberId);

            _display.ShowMemberHistory(member);
        }

        public void HandleRegisterMember()
        {
            string name = ThemeHelper.Prompt("Full Name");

            string phone = ThemeHelper.Prompt("Phone Number");

            if (!phone.Contains("0") && !phone.Contains("1") && !phone.Contains("2") && !phone.Contains("3") && !phone.Contains("4") && !phone.Contains("5") && !phone.Contains("6") && !phone.Contains("7") && !phone.Contains("8") && !phone.Contains("9"))
            {
                throw new InvalidOperationException(
                    "Phone number must contain at least one digit."
                );
            }

            string email = ThemeHelper.Prompt("Email Address");

            if (!email.Contains("@"))
                throw new InvalidOperationException(
                    "Invalid email format. Must contain '@' and domain."
                );

            Member member = _branch.RegisterMember(name, phone);
            _display.ShowRegistrationSuccess(member);
        }
    }
}