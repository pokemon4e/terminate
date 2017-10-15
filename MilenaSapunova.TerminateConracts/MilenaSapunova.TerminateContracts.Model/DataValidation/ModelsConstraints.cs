namespace MilenaSapunova.TerminateContracts.Model.DataValidation
{
    public static class ModelsConstraints
    {

        public const int NameMinLenght = 2;
        public const int NameMaxLenght = 50;

        public const int ContractTitleMinLength = 3;
        public const int ContractTitleMaxLength = 30;

        public const int ContractNumberMinLength = 3;
        public const int ContractNumberMaxLength = 30;

        public const string PhoneNumberContents = @"^00[0-9]{6,15}$";
        public const int PhoneNumberMinLength = 8;
        public const int PhoneNumberMaxLength = 17;
    }
}
