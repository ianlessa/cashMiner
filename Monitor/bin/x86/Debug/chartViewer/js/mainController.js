app.controller("mainController",function($scope){
			
			
	$scope.stock = {
		Name: "DefaultStockName"
	};
	
	
	$scope.openDevTools = function() {
		chartViewer.openDevTools();
	}
	
	
	
	chartViewer.getStock().then(function(data){
		
		
		$scope.stock = JSON.parse(data);
		$scope.stock.Logo = $scope.stock.Ticker.replace(/[0-9]/g, '');		
		$scope.$digest();		
		console.info("stock Loaded",$scope.stock);
	});
	
	chartViewer.getCandleList().then(function(data){
		 	
		
		$scope.stock.candleList = JSON.parse(data); 
		var candleList = [];		
		var max = $scope.stock.candleList.length;
		var start = max - 50;
		for(var i = start; i < max; i++)  {
			var element = $scope.stock.candleList[i];
			  
			candleList.push(new Candle(
                    element.DateTime,
                    "end",
                    element.Low,
                    element.Open,
                    element.Close,
                    element.High,
                    element.Volume
                ));
		}
			
		$scope.candleChart = new CandleChart(candleList);
		$scope.candleChart.update();
				
		$scope.$digest();		
				
		console.info("candlelist Loaded",candleList);
		
		//$scope.candleChart = new CandleChart(candleList);
		
		
	});
	
	
	

    console.info("mainController Loaded");
});