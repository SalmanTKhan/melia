//--- Melia Script -----------------------------------------------------------
// Praying for Their Rest (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Necromancer Lemija.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(80058)]
public class Quest80058Script : QuestScript
{
	protected override void Load()
	{
		SetId(80058);
		SetName("Praying for Their Rest (3)");
		SetDescription("Talk with Necromancer Lemija");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_06"));

		AddDialogHook("TABLELAND_11_1_LEMIJA2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_SQ_07_ENDNPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_11_1_SQ_07_start", "TABLELAND_11_1_SQ_07", "Let's leave now", "I'm not ready yet"))
		{
			case 1:
				dialog.HideNPC("TABLELAND_11_1_LEMIJA2");
				// Func/TABLELAND_11_1_SQ_07_NPC;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("TABLELAND_11_1_SQ_07_succ");
		await dialog.Msg("NPCAin/TABLELAND_11_1_SQ_07_ENDNPC/absorb/0");
		ZoneServer.Instance.World.FindNPC("TABLELAND_11_1_SQ_07_ENDNPC")?.PlayEffectLocal(character.Connection, "E_wizard_shoggoth_force", 1f, "MID");
		await Task.Delay(1000);
		ZoneServer.Instance.World.FindNPC("TABLELAND_11_1_DARK_WALL")?.PlayEffectLocal(character.Connection, "F_smoke019_dark", 1f, "BOT");
		dialog.HideNPC("TABLELAND_11_1_DARK_WALL");
		dialog.HideNPC("TABLELAND_11_1_SQ_07_BACK");
		await Task.Delay(1000);
		await dialog.Msg("NPCAin/TABLELAND_11_1_SQ_07_ENDNPC/rest_ready/1");
		await dialog.Msg("TABLELAND_11_1_SQ_09_succ_after");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("TABLELAND_11_1_SQ_08");
	}
}

