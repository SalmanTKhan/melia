//--- Melia Script -----------------------------------------------------------
// Bishop Urbonas' Whereabouts (2)
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

[QuestScript(60116)]
public class Quest60116Script : QuestScript
{
	protected override void Load()
	{
		SetId(60116);
		SetName("Bishop Urbonas' Whereabouts (2)");
		SetDescription("Talk with Priest Pranas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON621_MQ_01"));

		AddDialogHook("PRISON621_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_MQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON621_MQ_02_01", "PRISON621_MQ_02", "I'll check", "I'm afraid"))
		{
			case 1:
				dialog.UnHideNPC("PRISON621_MQ_02_NPC");
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
		character.Quests.Start("PRISON621_MQ_03");
	}
}

