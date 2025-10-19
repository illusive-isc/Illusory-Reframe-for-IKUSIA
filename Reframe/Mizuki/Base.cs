using System;
using System.Collections.Generic;
using System.Linq;
using VRC.SDK3.Avatars.Components;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    public class Base : BaseAbstract
    {
        protected void DeleteBarCtrlHandHit(List<string> Parameters, params string[] stateNames)
        {
            for (int i = 0; i < paryi_FX.layers.Length; i++)
            {
                var layer = paryi_FX.layers[i];
                if (layer.name is "BarCtrlHandHit")
                {
                    RemoveStatesAndTransitions(
                        layer.stateMachine,
                        layer
                            .stateMachine.states.Where(s =>
                            {
                                if (stateNames.Contains(s.state.name))
                                    return true;
                                foreach (var behaviour in s.state.behaviours)
                                    if (behaviour is VRCAvatarParameterDriver paramDriver)
                                        foreach (var parameter in paramDriver.parameters)
                                            return Parameters.Contains(parameter.name);

                                return false;
                            })
                            .Select(s => s.state)
                            .ToArray()
                    );
                    if (layer.stateMachine.states.Length == 1)
                        paryi_FX.RemoveLayer(i);
                }
            }
        }

        protected void DeleteBarCtrl(params string[] stateNames)
        {
            for (int i = 0; i < paryi_FX.layers.Length; i++)
            {
                var layer = paryi_FX.layers[i];
                if (layer.name is "BarCtrl")
                {
                    RemoveStatesAndTransitions(
                        layer.stateMachine,
                        layer
                            .stateMachine.states.Where(s =>
                            {
                                if (stateNames.Contains(s.state.name))
                                    return true;

                                return false;
                            })
                            .Select(s => s.state)
                            .ToArray()
                    );
                    if (layer.stateMachine.states.Length <= 2)
                        paryi_FX.RemoveLayer(i);
                }
            }
        }

        internal void DeleteMenuButtonCtrl(List<string> Parameters)
        {
            var layer = paryi_FX.layers.FirstOrDefault(l => l.name == "MenuButtonCtrl");
            if (layer != null)
            {
                var offState = layer.stateMachine.states.FirstOrDefault(s => s.state.name == "off");
                if (offState.state != null)
                {
                    RemoveStatesAndTransitions(
                        layer.stateMachine,
                        offState
                            .state.transitions.Where(t =>
                                t.destinationState != null
                                && t.conditions.Any(c => Parameters.Contains(c.parameter))
                            )
                            .Select(t => t.destinationState)
                            .ToArray()
                    );
                }
            }
        }

        internal override void ParticleOptimize()
        {
            SetMaxParticle("Advanced/Particle/1/breath", 100);
            SetMaxParticle("Advanced/Particle/2/WaterFoot_R/WaterFoot2/WaterFoot3", 10);
            SetMaxParticle("Advanced/Particle/2/WaterFoot_R/WaterFoot2/WaterFoot3/WaterFoot4", 10);
            SetMaxParticle("Advanced/Particle/2/WaterFoot_L/WaterFoot2/WaterFoot3", 10);
            SetMaxParticle("Advanced/Particle/2/WaterFoot_L/WaterFoot2/WaterFoot3/WaterFoot4", 10);
            SetMaxParticle("Advanced/Particle/3/Headbubbles/bubbles", 50);
            SetMaxParticle("Advanced/Particle/3/Headbubbles/bubbles/bubbles2", 50);
            SetMaxParticle("Advanced/Particle/3/Headbubbles/bubbles_Idol", 50);
            SetMaxParticle("Advanced/Particle/3/Headbubbles/bubbles_Idol/bubbles2", 50);
            SetMaxParticle("Advanced/Particle/5/8bitheart", 5);
            SetMaxParticle("Advanced/Particle/5/8bitheart/8bitheart flare", 15);

            SetMaxParticle("Advanced/HeartGunR/HeartGunFLY/HeartGunFLY2", 50);
            SetMaxParticle("Advanced/HeartGunR/HeartGunFLY/HeartGunFLY2/kira", 3200);
            SetMaxParticle("Advanced/HeartGunR/HeartGunFLY/HeartGunFLY2/Heart", 100);
            SetMaxParticle("Advanced/HeartGunR/HeartGunFLY/HeartGunFLY2/shot2", 400);
            SetMaxParticle("Advanced/HeartGunR/HeartGunFLY/HeartGunFLY2/shot2 (1)", 400);
            SetMaxParticle("Advanced/HeartGunR/HeartGunFLY/HeartGunChargeStay", 50);

            SetMaxParticle("Advanced/HeartGunR/HeartGunCollider/HeadHit/HeadHit", 50);
            SetMaxParticle("Advanced/HeartGunR/HeartGunCollider/HeadHit/Heart (1)", 50);

            SetMaxParticle("Advanced/HeartGunL/HeartGunFLY/HeartGunFLY2", 50);
            SetMaxParticle("Advanced/HeartGunL/HeartGunFLY/HeartGunFLY2/kira", 3200);
            SetMaxParticle("Advanced/HeartGunL/HeartGunFLY/HeartGunFLY2/Heart", 100);
            SetMaxParticle("Advanced/HeartGunL/HeartGunFLY/HeartGunFLY2/shot2", 400);
            SetMaxParticle("Advanced/HeartGunL/HeartGunFLY/HeartGunFLY2/shot2 (1)", 400);
            SetMaxParticle("Advanced/HeartGunL/HeartGunFLY/HeartGunChargeStay", 50);
            SetMaxParticle("Advanced/HeartGunL/HeartGunCollider/HeadHit/HeadHit", 50);
            SetMaxParticle("Advanced/HeartGunL/HeartGunCollider/HeadHit/Heart (1)", 50);
            SetMaxParticle("Advanced/HeartGunR2/HeartGunFLY/HeartGunFLY2", 50);
            SetMaxParticle("Advanced/HeartGunR2/HeartGunFLY/HeartGunFLY2/kira", 3200);
            SetMaxParticle("Advanced/HeartGunR2/HeartGunFLY/HeartGunFLY2/Heart", 100);
            SetMaxParticle("Advanced/HeartGunR2/HeartGunFLY/HeartGunFLY2/shot2", 400);
            SetMaxParticle("Advanced/HeartGunR2/HeartGunFLY/HeartGunFLY2/shot2 (1)", 400);
            SetMaxParticle("Advanced/HeartGunR2/HeartGunFLY/HeartGunChargeStay", 50);
            SetMaxParticle("Advanced/HeartGunL2/HeartGunFLY/HeartGunFLY2", 50);
            SetMaxParticle("Advanced/HeartGunL2/HeartGunFLY/HeartGunFLY2/kira", 3200);
            SetMaxParticle("Advanced/HeartGunL2/HeartGunFLY/HeartGunFLY2/Heart", 100);
            SetMaxParticle("Advanced/HeartGunL2/HeartGunFLY/HeartGunFLY2/shot2", 1200);
            SetMaxParticle("Advanced/HeartGunL2/HeartGunFLY/HeartGunFLY2/shot2 (1)", 1200);
            SetMaxParticle("Advanced/HeartGunL2/HeartGunFLY/HeartGunChargeStay", 50);
            SetMaxParticle("Advanced/AFK_World/position/swim/Particle System", 10);
            SetMaxParticle("Advanced/AFK_World/position/IdolParticle", 1);
            SetMaxParticle("Advanced/AFK_World/position/AFKIN Particle/AFK In0", 1);
            SetMaxParticle("Advanced/AFK_World/position/AFKIN Particle/AFK In1", 1);
            SetMaxParticle("Advanced/AFK_World/position/AFKIN Particle/AFK In1/IN S1", 1);
            SetMaxParticle("Advanced/AFK_World/position/AFKIN Particle/AFK In2", 20);
            SetMaxParticle("Advanced/AFK_World/position/AFKIN Particle/AFK In2/AFK In (1)", 20);
            SetMaxParticle("Advanced/AFK_World/position/AFKIN Particle/IN S3", 1);
            SetMaxParticle("Advanced/AFK_World/position/AFKIN Particle/IN S3/AFK In (1)", 1);
            SetMaxParticle("Advanced/Pet model/Constraint/Constraint/shark/bubbles_Idol", 10);
            SetMaxParticle("Advanced/Pet model/Constraint/Constraint/zzz", 1);
            SetMaxParticle("Advanced/Pet model/Constraint/Constraint/zzz/zzz2", 3);
            SetMaxParticle("Advanced/Pet model/Constraint/Constraint/zzz/zzz2/zzz3", 3);

            SetMaxParticle("Advanced/butterfly/world/target_constraint/cyou/idolParticle", 20);
            SetMaxParticle(
                "Advanced/butterfly/world/target_constraint/cyou/idolParticle/idolParticle2",
                20
            );
            SetMaxParticle(
                "Advanced/butterfly/world/target_constraint/cyou/idolParticle/idolParticle2/idolParticle3",
                20
            );
            SetMaxParticle("Advanced/butterfly/world/target_constraint/deru", 20);
            SetMaxParticle("Advanced/butterfly/world/target_constraint/orbit", 20);
            SetMaxParticle("Advanced/butterfly/world/target_constraint/kabecollision", 1);
            SetMaxParticle("Advanced/butterfly/IndexHandR/handtap_ONOFF/handtap", 10);

            SetMaxParticle("Advanced/Particle/7/2/pen1_R/PenParticle", 10000);
            SetMaxParticle("Advanced/Particle/7/2/pen1_R/PenParticle/SubEmitter0", 5000);
            SetMaxParticle("Advanced/Particle/7/4/pen1_L/PenParticle", 10000);
            SetMaxParticle("Advanced/Particle/7/4/pen1_L/PenParticle/SubEmitter0", 5000);
        }
    }
}
