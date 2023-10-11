//--- Melia Script -----------------------------------------------------------
// Mage Tower 4th Floor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita at Mage Tower 4F.
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

[QuestScript(8488)]
public class Quest8488Script : QuestScript
{
	protected override void Load()
	{
		SetId(8488);
		SetName("Mage Tower 4th Floor (1)");
		SetDescription("Talk to Grita at Mage Tower 4F");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("FTOWER43_MQ_06"));

		AddObjective("kill0", "Kill 12 Black Desmodus(s) or Wizard Shaman Doll(s) or Flask(s) or Minivern(s)", new KillObjective(12, 57220, 47401, 47396, 57050));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("FTOWER44_GRITA_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER44_MQ_01_01", "FTOWER44_MQ_01", "I agree to Grita's words", "It will be ok"))
		{
			case 1:
				dialog.HideNPC("FTOWER44_GRITA_01");
				await Task.Delay(500);
				// Func/FTOWER44_MQ_01_RUNNPC;
				await dialog.Msg("CameraShockWaveLocal/2/99999/10/2/200/0");
				await dialog.Msg("FTOWER44_MQ_01_AG");
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

		await dialog.Msg("FTOWER44_MQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER44_MQ_02");
	}
}

