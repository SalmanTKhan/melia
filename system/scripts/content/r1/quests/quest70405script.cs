//--- Melia Script -----------------------------------------------------------
// Preparations Complete
//--- Description -----------------------------------------------------------
// Quest to Talk to Mage Melchioras.
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

[QuestScript(70405)]
public class Quest70405Script : QuestScript
{
	protected override void Load()
	{
		SetId(70405);
		SetName("Preparations Complete");
		SetDescription("Talk to Mage Melchioras");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_1_MQ05"));

		AddDialogHook("CASTLE651_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_MQ_01_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE651_MQ_06_start", "CASTLE65_1_MQ06", "Let's meet at Delmore Manor", "I can only help so much"))
		{
			case 1:
				dialog.HideNPC("CASTLE651_MQ_01");
				dialog.HideNPC("CASTLE651_MQ_03");
				await dialog.Msg("FadeOutIN/2000");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CASTLE65_2_MQ01");
	}
}

