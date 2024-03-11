//--- Melia Script -----------------------------------------------------------
// Soul Hunter (2)
//--- Description -----------------------------------------------------------
// Quest to Conversation with gloomy owl image.
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

[QuestScript(8320)]
public class Quest8320Script : QuestScript
{
	protected override void Load()
	{
		SetId(8320);
		SetName("Soul Hunter (2)");
		SetDescription("Conversation with gloomy owl image");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_13"));

		AddDialogHook("KATYN18_OWL_04", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_14_01", "KATYN18_MQ_14", "We propose that you want to remove the trap", "Cancel"))
		{
			case 1:
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

		await dialog.Msg("KATYN18_MQ_14_03");
		ZoneServer.Instance.World.FindNPC("KATYN18_OWL_04")?.PlayEffectLocal(character.Connection, "F_light018", 1f, "MID");
		await dialog.Msg("NPCForceEffect/KATYN18_OWL_04/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_15");
	}
}

