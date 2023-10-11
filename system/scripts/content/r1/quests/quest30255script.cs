//--- Melia Script -----------------------------------------------------------
// Vincentas' Squan In Peril(2)
//--- Description -----------------------------------------------------------
// Quest to Search for Ebonypawn in the Armory.
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

[QuestScript(30255)]
public class Quest30255Script : QuestScript
{
	protected override void Load()
	{
		SetId(30255);
		SetName("Vincentas' Squan In Peril(2)");
		SetDescription("Search for Ebonypawn in the Armory");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CASTLE_20_4_SQ_2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_1"));

		AddObjective("kill0", "Kill 1 Magic Suppressor", new KillObjective(1, MonsterId.Spell_Suppressors));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("CASTLE_20_4_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_4_SQ_2_select", "CASTLE_20_4_SQ_2", "Don't worry.", "I need a minute prepare"))
		{
			case 1:
				await dialog.Msg("CASTLE_20_4_SQ_2_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

