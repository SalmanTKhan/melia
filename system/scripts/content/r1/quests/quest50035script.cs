//--- Melia Script -----------------------------------------------------------
// The Disappearance (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the spirit of Klaipeda's Mayor.
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

[QuestScript(50035)]
public class Quest50035Script : QuestScript
{
	protected override void Load()
	{
		SetId(50035);
		SetName("The Disappearance (3)");
		SetDescription("Talk to the spirit of Klaipeda's Mayor");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_041"));

		AddDialogHook("KLAIPEDA_MAYER", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_042_startnpc01", "PARTY_Q_042", "Tell Sir Uska about it", "Take some time to think about it"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_042_startnpc02");
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

		await dialog.Msg("PARTY_Q_042_succ01");
		dialog.HideNPC("KLAIPEDA_MAYER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

