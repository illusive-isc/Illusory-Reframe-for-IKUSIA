using System.Collections.Generic;
using System.Linq;

namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Mizuki
{
    internal class Drink : MizukiBase
    {
        internal override List<string> GetParameters() =>
            new() { "Gimmick2_6", "Drinkhight", "Drinkmouth", "DrinkReset" };

        internal override List<string> GetMenuPath() => new() { "Gimmick2", "Gimmick6" };

        internal override List<string> GetDelPath() => new() { "Advanced/Gimmick2/6" };

        internal override void DeleteFx(List<string> Layers)
        {
            paryi_FX
                .layers.Where(layer => layer.name == "LipSynk")
                .ToList()
                .ForEach(layer =>
                {
                    var delList = new List<string>()
                    {
                        "mouse0 0 0 0",
                        "Drinkhight1",
                        "mouse0 0 1",
                    };

                    RemoveStatesAndTransitions(
                        layer.stateMachine,
                        layer
                            .stateMachine.states.Where(state => delList.Contains(state.state.name))
                            .Select(state => state.state)
                            .ToArray()
                    );
                });
        }
    }
}
