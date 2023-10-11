//--- Melia Script -----------------------------------------------------------
// Oil and water
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Mylija.
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

[QuestScript(70830)]
public class Quest70830Script : QuestScript
{
	protected override void Load()
	{
		SetId(70830);
		SetName("Oil and water");
		SetDescription("Talk to Refugee Mylija");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MAPLE23_2_SQ11_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ03"));

		AddDialogHook("MAPLE232_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_12", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_11_start", "MAPLE23_2_SQ11"))
		{
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
		character.Quests.Start("MAPLE23_2_SQ12");
	}
}

