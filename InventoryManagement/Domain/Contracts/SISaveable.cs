namespace InventoryManagement.Domain.Contracts
{
    internal interface ISaveable
    {
        string ConvertToStringForSaving();
    }
}