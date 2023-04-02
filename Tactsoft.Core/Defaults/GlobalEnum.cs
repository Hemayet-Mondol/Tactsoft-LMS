namespace Tactsoft.Core.Defaults
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Divorced = 3,
        Widow = 4
    }

    public enum Status
    {
        Initial = 1,
        Pending,
        NoAssigned,
        InProgress,
        DonePayment,
        Reverted,
        Failed,
        Completed,
        Downloaded
    }

    public enum MessageType : int
    {
        All = 1,
        Sms = 2,
        Email = 3
    }
/*    public enum UserType
    {
        Admin = 1,
        Trainer = 2,
        Student = 3,

    }*/
    public enum Month
    {
        Janurary=1,
        February,
        March,
        April,
        May,
        June,
        July,
        Auguest,
        September,
        October,
        November,
        December
    }
}
