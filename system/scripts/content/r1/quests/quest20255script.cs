//--- Melia Script -----------------------------------------------------------
// In the Name of Faith (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Virgis.
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

[QuestScript(20255)]
public class Quest20255Script : QuestScript
{
	protected override void Load()
	{
		SetId(20255);
		SetName("In the Name of Faith (1)");
		SetDescription("Talk to Believer Virgis");

		AddPrerequisite(new LevelPrerequisite(59));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1062));

		AddDialogHook("THORN19_BELIEVER03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN19_MQ11_select01", "THORN19_MQ11", "I'll help if I can", "About the evil energy in the Thorn Forest", "I have nothing to do with it"))
		{
			case 1:
				await dialog.Msg("THORN19_MQ11_startnpc01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN19_MQ11_add");
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN19_MQ12");
	}
}

