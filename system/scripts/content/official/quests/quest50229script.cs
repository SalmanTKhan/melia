//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(9)
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

[QuestScript(50229)]
public class Quest50229Script : QuestScript
{
	protected override void Load()
	{
		SetId(50229);
		SetName("Maven's Wishes(9)");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ7"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN43_4_SQ8_START1", "BRACKEN43_4_SQ8", "Ask how you should help", "I will find it later"))
			{
				case 1:
					await dialog.Msg("BRACKEN43_4_SQ8_AGREE1");
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
			if (character.Inventory.HasItem("BRACKEN434_SUBQ8_ITEM1", 11))
			{
				character.Inventory.RemoveItem("BRACKEN434_SUBQ8_ITEM1", 11);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("BRACKEN43_4_SQ8_SUCC1");
				await dialog.Msg("EffectLocalNPC/BRACKEN434_SUBQ1_NPC4/F_pc_making_finish_white/2/TOP");
				await Task.Delay(2000);
				await dialog.Msg("BRACKEN43_4_SQ8_SUCC1_1");
				await dialog.Msg("BalloonText/BRACKEN434_SUBQ3_DLG/3");
				await dialog.Msg("FadeOutIN/1500");
				await dialog.Msg("BRACKEN43_4_SQ8_SUCC2");
				dialog.HideNPC("BRACKEN434_SUBQ1_NPC4");
				await dialog.Msg("FadeOutIN/1000");
				dialog.UnHideNPC("BRACKEN434_SUBQ1_NPC1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

