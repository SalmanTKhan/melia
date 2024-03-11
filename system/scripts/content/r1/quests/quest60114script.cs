//--- Melia Script -----------------------------------------------------------
// The Dangerous Trace (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(60114)]
public class Quest60114Script : QuestScript
{
	protected override void Load()
	{
		SetId(60114);
		SetName("The Dangerous Trace (3)");
		SetDescription("Talk with Priest Pranas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORSHA_MQ2_02"));

		AddDialogHook("C_ORSHA_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_PRANAS_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORSHA_MQ2_03_01", "ORSHA_MQ2_03", "I will follow soon", "Tell him to wait a bit"))
		{
			case 1:
				await dialog.Msg("ORSHA_MQ2_03_01_1");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("C_ORSHA_PRANAS");
				dialog.UnHideNPC("SIAU11RE_TORNAVA");
				dialog.UnHideNPC("SIAU11RE_DARAMAUS");
				dialog.UnHideNPC("SIAULIAI11RE_PRANAS_1");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Join Pranas in front of the Gebene Cliff in Paupys Crossing!");
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


		return HookResult.Break;
	}
}

