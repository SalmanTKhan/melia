//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Lintas.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;
using Melia.Shared.Tos.Const;

[QuestScript(50227)]
public class Quest50227Script : QuestScript
{
	protected override void Load()
	{
		SetId(50227);
		SetName("Maven's Wishes(7)");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ5"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddObjective("collect0", "Collect 12 Dry Vilkas Skin(s)", new CollectItemObjective("BRACKEN434_SUBQ6_ITEM1", 12));
		AddDrop("BRACKEN434_SUBQ6_ITEM1", 7.5f, 58456, 58454);

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUB6_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN43_4_SQ6_START1", "BRACKEN43_4_SQ6", "I will go get it", "I will obtain them later"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("BRACKEN434_SUBQ6_ITEM1", 12))
			{
				character.Inventory.RemoveItem("BRACKEN434_SUBQ6_ITEM1", 12);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/BRACKEN434_SUB6_NPC2/F_burstup036_fire/0.3/BOT");
				await dialog.Msg("EffectLocalNPC/BRACKEN434_SUB6_NPC1/F_burstup036_fire/0.3/BOT");
				dialog.HideNPC("BRACKEN434_SUB6_NPC2");
				dialog.HideNPC("BRACKEN434_SUB6_NPC1");
				await dialog.Msg("BRACKEN43_4_SQ6_SUCC1");
				// Func/BRACKEN434_SUBQ6_COMPLETE;
				await dialog.Msg("BRACKEN43_4_SQ6_SUCC2");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

