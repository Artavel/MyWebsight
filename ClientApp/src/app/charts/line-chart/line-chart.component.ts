import { Component, OnInit } from '@angular/core';
import { LINE_CHART_COLORS } from '../../shared/chart.colors';
 const LINE_CHART_SAMPLE_DATA: any[] = [
   { data: [32, 14, 46, 23, 38, 56], label: 'Sentimental Analysis' },
   { data: [12, 18, 26, 13, 69, 26], label: 'Image Recognition' },
   { data: [52, 14, 46, 53, 20, 72], label: 'Forecasting' }
 ];

 const LINE_CHART_LABELS: string[] = [
   'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'
  ];

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor() { }

  lineChartData = LINE_CHART_SAMPLE_DATA;
  lineChartLabels = LINE_CHART_LABELS;
  lineChartOptions: any = {
    responsive: true
  };
  lineChartLegend: true;
  lineChartType = 'line';
  lineChartColors = LINE_CHART_COLORS;

  ngOnInit(): void {
  }

}
