//--- Melia Script -----------------------------------------------------------
// The Master's Legacy
//--- Description -----------------------------------------------------------
// Quest to Talk to Disciple Laius.
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

[QuestScript(30002)]
public class Quest30002Script : QuestScript
{
	protected override void Load()
	{
		SetId(30002);
		SetName("The Master's Legacy");
		SetDescription("Talk to Disciple Laius");

		AddPrerequisite(new LevelPrerequisite(188));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_2_SQ_01"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5828));

		AddDialogHook("CATACOMB_38_2_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_2_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_2_SQ_02_start", "CATACOMB_38_2_SQ_02", "Tell him that you will go gather vigor", "About the research of the master", "Tell him to do it himself from now on"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CATACOMB_38_2_SQ_02_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CATACOMB_38_2_SQ_02_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_2_SQ_03");
	}
}

