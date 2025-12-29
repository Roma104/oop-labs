using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    // W³aœciwoœæ przechowuj¹ca zalogowan¹ historiê symulacji
    public SimulationLog? Log { get; private set; }
    public int CurrentTurn { get; private set; }

    private void SetupSimulation()
    {

        var map = new SmallTorusMap(8, 6);
        var imapables = new List<IMapable> {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 5, CanFly = true },
            new Birds { Description = "Ostriches", Size = 3, CanFly = false }
        };
        var points = new List<Point> {
            new(3, 1), new(2, 2), new(5, 5), new(7, 3), new(0, 4)
        };

        var simulation = new Simulation(map, imapables, points, "dlrludluddlrulr");
        Log = new SimulationLog(simulation);
    }

    public void OnGet()
    {
        SetupSimulation();
        CurrentTurn = HttpContext.Session.GetInt32("Turn") ?? 0;
    }

    public IActionResult OnPostPrev()
    {
        SetupSimulation();
        CurrentTurn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (CurrentTurn > 0) CurrentTurn--;
        HttpContext.Session.SetInt32("Turn", CurrentTurn);
        return Page(); 
    }

    public IActionResult OnPostNext()
    {
        SetupSimulation();
        CurrentTurn = HttpContext.Session.GetInt32("Turn") ?? 0;
        if (Log != null && CurrentTurn < Log.TurnLogs.Count - 1) CurrentTurn++;
        HttpContext.Session.SetInt32("Turn", CurrentTurn);
        return Page();
    }


}