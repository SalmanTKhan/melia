//--- Melia Script -----------------------------------------------------------
// Jonas' Medicine (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Davio.
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

[QuestScript(4441)]
public class Quest4441Script : QuestScript
{
	protected override void Load()
	{
		SetId(4441);
		SetName("Jonas' Medicine (3)");
		SetDescription("Talk to Merchant Davio");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_11"));
		AddPrerequisite(new ItemPrerequisite("ROKAS24_QB_11_DRUG", -100));

		AddDialogHook("ROKAS24_DABIO", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_FLORIJONAS2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_14_select1", "ROKAS24_QB_14", "I will go see Jonas", "I will bring it later"))
		{
			case 1:
				await dialog.Msg("ROKAS24_QB_14_Q");
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

		await dialog.Msg("ROKAS24_QB_14_succ1");
		await dialog.Msg("ROKAS24_QB_14_succ2");
		await Task.Delay(2000);
		await dialog.Msg("BalloonText/ROKAS24_QB_14_succ4/2");
		await dialog.Msg("NPCAin/ROKAS_24_FLORIJONAS2/event_drink/0");
		ZoneServer.Instance.World.FindNPC("ROKAS_24_FLORIJONAS2")?.PlayEffectLocal(character.Connection, "F_burstup001_red", 0.5f, "BOT");
		await Task.Delay(3000);
		await dialog.Msg("ROKAS24_QB_14_succ3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS24_QB_8");
	}
}

