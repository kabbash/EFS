export class Calculator {

    age: number;
    height: number;
    weight: number;
    neck: number;
    waist: number;
    hip: number;
    fats: number;
    carbPercentage: number;
    gender: string = "0";
    equation: string = "0";
    activityRange: string = "1";
    showResult: boolean = false;
    caloriesResult = new caloriesResult();
    healthyFatsResult = new healthyFatsResult();
    bodyFatsResult = new bodyFatsResult();
    carbResult = new carbResult();
    proteinResult = new proteinResult();
    perfectWeightResult = new perfectWeightResult();

    reset() {
        this.activityRange = "1";
        this.age = undefined;
        this.equation = "0";
        this.gender = "0";
        this.height = undefined;
        this.weight = undefined;
        this.neck = undefined;
        this.waist = undefined;
        this.hip = undefined;
        this.fats = undefined;
        this.carbPercentage = undefined;
        this.healthyFatsResult = new healthyFatsResult();
        this.bodyFatsResult = new bodyFatsResult();
        this.carbResult = new carbResult();
        this.proteinResult = new proteinResult();
        this.perfectWeightResult = new perfectWeightResult();
        this.showResult = false;
    }
    calcCalories() {
        let calories = 0;
        switch (this.equation) {
            case "1":

                if (this.gender == "0")
                    calories = (13.397 * this.weight) + (4.799 * this.height) - (5.677 * this.age) + 88.362;
                else
                    calories = (9.247 * this.weight) + (3.098 * this.height) - (4.330 * this.age) + 447.593;
                break;

            case "2":
                calories = 370 + (21.6 * (1 - (this.fats / 100)) * this.weight);
                break;

            default:
                calories = (10 * this.weight) + (6.25 * this.height) - (5 * this.age);

                if (this.gender == "1")
                    calories -= 161;
                else
                    calories += 5;

                break;
        }

        calories *= Number(this.activityRange);
        this.caloriesResult.maintainWeight = isNaN(calories) ? "0" : calories.toFixed();
        this.caloriesResult.lossHalfKilo = isNaN(calories) ? "0" : (calories - 500).toFixed();
        this.caloriesResult.lossOneKilo = isNaN(calories) ? "0" : (calories - 1000).toFixed();
        this.caloriesResult.gainHalfKilo = isNaN(calories) ? "0" : (calories + 500).toFixed();
        this.caloriesResult.gainOneKilo = isNaN(calories) ? "0" : (calories + 1000).toFixed();
        this.showResult = true;
    }
    calcCarb() {
        this.equation = "0";
        this.calcCalories();
        this.carbResult.maintainWeight = (((this.carbPercentage / 100) * Number(this.caloriesResult.maintainWeight)) / 3.75).toFixed();
        this.carbResult.lossHalfKilo = (((this.carbPercentage / 100) * Number(this.caloriesResult.lossHalfKilo)) / 3.75).toFixed();
        this.carbResult.lossOneKilo = (((this.carbPercentage / 100) * Number(this.caloriesResult.lossOneKilo)) / 3.75).toFixed();
        this.carbResult.gainHalfKilo = (((this.carbPercentage / 100) * Number(this.caloriesResult.gainHalfKilo)) / 3.75).toFixed();
        this.carbResult.gainOneKilo = (((this.carbPercentage / 100) * Number(this.caloriesResult.gainOneKilo)) / 3.75).toFixed();
    }
    calcHealthyFats() {
        this.equation = "0";
        this.calcCalories();
        this.healthyFatsResult.maintainWeight = (((20 / 100) * Number(this.caloriesResult.maintainWeight)) / 8.75).toFixed() + ' - ' + (((35 / 100) * Number(this.caloriesResult.maintainWeight)) / 8.75).toFixed();
        this.healthyFatsResult.lossHalfKilo = (((20 / 100) * Number(this.caloriesResult.lossHalfKilo)) / 8.75).toFixed() + ' - ' + (((35 / 100) * Number(this.caloriesResult.lossHalfKilo)) / 8.75).toFixed();
        this.healthyFatsResult.lossOneKilo = (((20 / 100) * Number(this.caloriesResult.lossOneKilo)) / 8.75).toFixed() + ' - ' + (((35 / 100) * Number(this.caloriesResult.lossOneKilo)) / 8.75).toFixed();
        this.healthyFatsResult.gainHalfKilo = (((20 / 100) * Number(this.caloriesResult.gainHalfKilo)) / 8.75).toFixed() + ' - ' + (((35 / 100) * Number(this.caloriesResult.gainHalfKilo)) / 8.75).toFixed();
        this.healthyFatsResult.gainOneKilo = (((20 / 100) * Number(this.caloriesResult.gainOneKilo)) / 8.75).toFixed() + ' - ' + (((35 / 100) * Number(this.caloriesResult.gainOneKilo)) / 8.75).toFixed();
    }
    calcProtein() {
        this.equation = "0";
        this.calcCalories();
        this.proteinResult.maintainWeight = (1.2 * Number(this.weight)).toFixed();
        this.proteinResult.gainWeight = (1.2 * Number(this.weight)).toFixed() + ' - ' + (1.6 * Number(this.weight)).toFixed();
        this.proteinResult.lossWeight = (1.6 * Number(this.weight)).toFixed() + ' - ' + (2.2 * Number(this.weight)).toFixed();
        this.showResult = true;
    }
    calcBodyFats() {

        let fats = 0;

        if (this.gender == "1") {
            let femaleMeasure = Number(this.waist) + Number(this.hip) - Number(this.neck);
            fats = (495 / (1.29579 - (0.35004 * Math.log10(femaleMeasure)) + (0.22100 * Math.log10(this.height)))) - 450;
        }
        else {
            fats = (495 / (1.0324 - (0.19077 * Math.log10(this.waist - this.neck)) + (0.15456 * Math.log10(this.height)))) - 450;
        }
        if (isNaN(fats))
            fats = 0;
        this.bodyFatsResult.fatsPercentage = fats.toFixed(1) + '%';
        this.bodyFatsResult.fatsKG = fats == 0 ? "0" : ((fats / 100) * this.weight).toFixed(1) + ' كجم ';
        this.bodyFatsResult.notFatsKG = fats == 0 ? "0" : (this.weight - ((fats / 100) * this.weight)).toFixed(1) + ' كجم ';

        let fatClass = "";
        if (this.gender == "1") {
            if (fats < 14)
                fatClass = "دهون اساسية";
            if (fats >= 14 && fats < 21)
                fatClass = "رياضى محترف";
            if (fats >= 21 && fats < 25)
                fatClass = "فتنس";
            if (fats >= 25 && fats < 32)
                fatClass = "متوسط";
            if (fats >= 32)
                fatClass = "سمين";

        } else {
            if (fats < 6)
                fatClass = "دهون اساسية";
            if (fats >= 6 && fats < 14)
                fatClass = "رياضى محترف";
            if (fats >= 14 && fats < 18)
                fatClass = "فتنس";
            if (fats >= 18 && fats < 25)
                fatClass = "متوسط";
            if (fats >= 25)
                fatClass = "سمين";
        }
        this.bodyFatsResult.fatClass = fats == 0 ? "غير مصنف" : fatClass;
        this.showResult = true;
    }
    calcPerfectWeight() {
        let miller = "0";
        if (this.gender == "1") {
            miller = (53.1 + (1.36 * ((this.height - 152) / 2.5))).toFixed();
        } else {
            miller = (56.2 + (1.41 * ((this.height - 152) / 2.5))).toFixed();
        }
        this.perfectWeightResult.miller = miller;
        this.showResult = true;
    }
}

export class caloriesResult {
    maintainWeight: string;
    lossHalfKilo: string;
    lossOneKilo: string;
    gainHalfKilo: string;
    gainOneKilo: string;
}
export class carbResult {
    maintainWeight: string;
    lossHalfKilo: string;
    lossOneKilo: string;
    gainHalfKilo: string;
    gainOneKilo: string;
}
export class healthyFatsResult {
    maintainWeight: string;
    lossHalfKilo: string;
    lossOneKilo: string;
    gainHalfKilo: string;
    gainOneKilo: string;
}
export class proteinResult {
    maintainWeight: string;
    lossWeight: string;
    gainWeight: string;
}
export class perfectWeightResult {
    robinson: string;
    hamwi: string;
    miller: string;
    devine: string;
    healthyBMI: string;
}
export class bodyFatsResult {
    fatsPercentage: string;
    fatsKG: string;
    notFatsKG: string;
    fatClass: string;
}