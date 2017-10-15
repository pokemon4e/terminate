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

        public const int AddressNameMinLenght = 5;
        public const int AddressNameMaxLenght = 200;

        public const int PostalCodeMinLenght = 2;
        public const int PostalCodeMaxLenght = 30;

        public const string PhoneNumberRegex = @"^00[0-9]{6,15}$";
        public const int PhoneNumberMinLength = 8;
        public const int PhoneNumberMaxLength = 17;

        public const string EmailRegex = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        public const int EmailMinLength = 3;
        public const int EmailMaxLength = 254;
    }
}
