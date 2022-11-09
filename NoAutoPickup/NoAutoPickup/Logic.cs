namespace NoAutoPickup
{
  public static class Logic
  {
    public static CraftTree.Type GetCraftTreeForGhostCrafter(GhostCrafter ghostCrafter) => ghostCrafter.craftTree;

    public static bool CraftTreeIsModded(CraftTree.Type type)
    {
      int num = (int) type;
      return num < 0 || num > 10;
    }

    public static bool ShouldDisableAutoPickupForCraftTree(CraftTree.Type type)
    {
      if (GameInput.GetButtonHeld(GameInput.Button.Sprint))
        return false;
      if (Logic.CraftTreeIsModded(type))
        return Mod.Config.NoAutoPickup_Modded;
      switch (type)
      {
        case CraftTree.Type.Fabricator:
          return Mod.Config.NoAutoPickup_Fabricator;
        case CraftTree.Type.Workbench:
          return Mod.Config.NoAutoPickup_ModificationStation;
        default:
          return Mod.Config.NoAutoPickup_Other;
      }
    }
  }
}
