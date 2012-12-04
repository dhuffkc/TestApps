Poller = function () {

	var subscribers = [];
	var timer;
	var values = [];

	var forcePoll = function () {
		var isPolling = timer != undefined;

		if (isPolling) {
			stop();
		}

		handleUpdate();

		if (isPolling) {
			stop();
		}
	};

	var handleUpdate = function () {
		console.log("handleUpdate: " + new Date().toLocaleTimeString());
		
		var newValue = new Date();
		var oldestTime = newValue.getTime() - 12 * 1000;

		var deletedValues = values.filter(function (element) {
			return element.getTime() < oldestTime;
		});

		values = values.filter(function (element) {
			return element.getTime() >= oldestTime;
		});

		var addedValues = [newValue];

		values = values.concat(addedValues);

		subscribers.forEach(function (subscriber) {
			subscriber(values, addedValues, deletedValues);
		});
	};

	var start = function () {
		handleUpdate();
		timer = setTimeout(start, 5000);
	};

	var stop = function () {
		if (timer != undefined) {
			clearTimeout(timer);
			timer = undefined;
		}
	};

	var subscribe = function (callback) {
		if (callback != undefined) {
			subscribers.push(callback);
			return callback;
		}

		return null;
	};

	var unsubscribe = function (subscription) {
		subscribers = subscribers.filter(function (element) {
			return element !== subscription;
		});
	};

	return {
		forcePoll: forcePoll
		, start: start
		, stop: stop
		, subscribe: subscribe
		, unsubscribe: unsubscribe
		, values: values
	};
};