using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("SIAUL_WEST_DRASIUS1_TRACK")]
public class SIAULWESTDRASIUS1TRACK : TrackScript
{
    protected override void Load()
    {
        SetId("SIAUL_WEST_DRASIUS1_TRACK");
        //SetMap("f_siauliai_west");
        //CenterPos(-1238.04,260.83,-585.43);
    }

    public override IActor[] OnStart(Character character, Track track)
    {
        base.OnStart(character, track);

        var actors = new List<IActor>();
        character.Movement.MoveTo(new Position(-1098.551f, 260.8354f, -544.0311f));
        actors.Add(character);

        var mob0 = Shortcuts.AddMonster(0, 10046, "Scout", "f_siauliai_west", -1121.16, 260.8354, -528.1818, 54, "Our_Forces");
        mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
        mob0.AddEffect(new ScriptInvisibleEffect());
        mob0.Layer = character.Layer;
        actors.Add(mob0);

        var mob1 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1231.022, 260.8354, -547.764, 16.875);
        mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
        mob1.AddEffect(new ScriptInvisibleEffect());
        mob1.Layer = character.Layer;
        actors.Add(mob1);

        var mob2 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1243.161, 260.8354, -563.113, 0);
        mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
        mob2.AddEffect(new ScriptInvisibleEffect());
        mob2.Layer = character.Layer;
        actors.Add(mob2);

        var mob3 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1262.53, 260.8354, -516.8501, 0);
        mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
        mob3.AddEffect(new ScriptInvisibleEffect());
        mob3.Layer = character.Layer;
        actors.Add(mob3);

        var mob4 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1261.328, 260.8354, -570.4838, 0);
        mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
        mob4.AddEffect(new ScriptInvisibleEffect());
        mob4.Layer = character.Layer;
        actors.Add(mob4);

        var mob5 = Shortcuts.AddMonster(0, 40070, "Soldier", "f_siauliai_west", -1277, 261, -614, 0);
        mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
        mob5.AddEffect(new ScriptInvisibleEffect());
        mob5.Layer = character.Layer;
        actors.Add(mob5);

        return actors.ToArray();
    }

    public override async Task OnProgress(Character character, Track track, int frame)
    {
        switch (frame)
        {
            case 1:
                //DRT_SETHOOKMSGOWNER(0, 0);
                break;
            case 6:
                break;
            case 9:
                break;
            case 10:
                break;
            case 12:
                break;
            case 21:
                //InsertHate(999);
                break;
            case 25:
                //InsertHate(999);
                break;
            case 27:
                //InsertHate(999);
                break;
            case 28:
                //InsertHate(999);
                break;
            case 29:
                CreateBattleBoxInLayer(character, track);
                //CREATE_BATTLE_BOX_INLAYER(0);
                //TRACK_SETTENDENCY();
                break;
            default:
                Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
                break;
        }
        await base.OnProgress(character, track, frame);
    }

}
