#r "nuget: Flips, Version=1.2.3"

open System
open Flips.Domain
open Flips.Solve

// Declare the parameters for our model
let hamburgerProfit = 1.50
let hotdogProfit = 1.20
let hamburgerBuns = 300.0
let hotdogBuns = 200.0
let hamburgerWeight = 0.5
let hotdogWeight = 0.4
let maxTruckWeight = 200.0

// Create Decision Variable with a Lower Bound of 0.0 and an Upper Bound of Infinity
let numberOfHamburgers = Decision.createContinuous "NumberOfHamburgers" 0.0 infinity
let numberOfHotdogs = Decision.createContinuous "NumberOfHotDogs" 0.0 infinity

// Create the Linear Expression for the objective
let objectiveExpression = hamburgerProfit * numberOfHamburgers + hotdogProfit * numberOfHotdogs

// Create an Objective with the name "MaximizeRevenue" the goal of Maximizing
// the Objective Expression
let objective = Objective.create "MaximizeRevenue" Maximize objectiveExpression

// Create a Constraint for the max number of Hamburger considering the number of buns
let maxHamburger = Constraint.create "MaxHamburger" (numberOfHamburgers <== hamburgerBuns)
// Create a Constraint for the max number of Hot Dogs considering the number of buns
let maxHotDog = Constraint.create "MaxHotDog" (numberOfHotdogs <== hotdogBuns)
// Create a Constraint for the Max combined weight of Hamburgers and Hotdogs
let maxWeight = Constraint.create "MaxWeight" (numberOfHotdogs * hotdogWeight + numberOfHamburgers * hamburgerWeight <== maxTruckWeight)

// Create a Model type and pipe it through the addition of the constraitns
let model =
    Model.create objective
    |> Model.addConstraint maxHamburger
    |> Model.addConstraint maxHotDog
    |> Model.addConstraint maxWeight

// Create a Settings type which tells the Solver which types of underlying solver to use,
// the time alloted for solving, and whether to write an LP file to disk
let settings = {
    SolverType = SolverType.CBC
    MaxDuration = 10_000L
    WriteLPFile = None
}

// Call the `solve` function in the Solve module to evaluate the model
let result = solve settings model
