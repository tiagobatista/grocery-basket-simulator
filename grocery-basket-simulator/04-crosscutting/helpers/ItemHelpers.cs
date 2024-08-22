public static class ItemHelpers{

    public static string NormalizeItemName(string itemName){
        return itemName.Trim().ToLowerInvariant();
    }
}