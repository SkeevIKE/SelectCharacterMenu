namespace SelectCharacterMenu
{
    public enum CharacterNames
    {
        Berserk,
        Hunter,
        Thief,
        Wildman
    }

    [System.Flags]
    public enum ArmorTypes
    {
        None = 0,
        Light = 1,
        Medium = 2,
        Heavy = 4
    }

    [System.Flags]
    public enum WeaponTypes
    {
        None = 0,
        Axe = 1,
        Hammer = 2,
        Sword = 4,
    }
}
