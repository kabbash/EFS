export class calroiesCalc {

    age: number;
    height: number;
    weight: number;
    fats: number;
    gender: string = "0";
    equation: string = "0";
    activityRange: string = "1";
    result = new caloriesResult();

    reset() {
        this.activityRange = "1";
        this.age = undefined;
        this.equation = "0";
        this.gender = "0";
        this.height = undefined;
        this.weight = undefined;
        this.fats = undefined;
        this.result = new caloriesResult();
    }
    calc() {

        let calories = 0;
        switch (this.equation) {
            case "1":

                if (this.gender == "0")
                    calories = (13.397 * this.weight) + (4.799 * this.height) - (5.677 * this.age) + 88.362;
                else
                    calories = (9.247 * this.weight) + (3.098 * this.height) - (4.330 * this.age) + 447.593;

                calories *= Number(this.activityRange);
                this.result.maintainWeight = isNaN(calories) ? "0" : calories.toFixed();
                this.result.lossQuarterKilo = isNaN(calories) ? "0" : (calories * 0.90).toFixed();
                this.result.lossHalfKilo = isNaN(calories) ? "0" : (calories * 0.81).toFixed();
                this.result.lossOneKilo = isNaN(calories) ? "0" : (calories * 0.61).toFixed();
                break;
            case "2":
                calories = 370 + (21.6 * (1 - (this.fats / 100)) * this.weight);

                calories *= Number(this.activityRange);
                this.result.maintainWeight = isNaN(calories) ? "0" : calories.toFixed();
                this.result.lossQuarterKilo = isNaN(calories) ? "0" : (calories * 0.89).toFixed();
                this.result.lossHalfKilo = isNaN(calories) ? "0" : (calories * 0.79).toFixed();
                this.result.lossOneKilo = isNaN(calories) ? "0" : (calories * 0.57).toFixed();

                break;

            default:
                calories = (10 * this.weight) + (6.25 * this.height) - (5 * this.age);

                if (this.gender == "1")
                    calories -= 161;
                else
                    calories += 5;

                calories *= Number(this.activityRange);
                this.result.maintainWeight = isNaN(calories) ? "0" : calories.toFixed();
                this.result.lossQuarterKilo = isNaN(calories) ? "0" : (calories * 0.90).toFixed();
                this.result.lossHalfKilo = isNaN(calories) ? "0" : (calories * 0.80).toFixed();
                this.result.lossOneKilo = isNaN(calories) ? "0" : (calories * 0.61).toFixed();
                break;
        }
    }
}

export class caloriesResult {
    maintainWeight: string;
    lossQuarterKilo: string;
    lossHalfKilo: string;
    lossOneKilo: string;
}