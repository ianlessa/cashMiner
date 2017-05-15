using System;


namespace Candles
{
    public class Candle
    {
        private int size; //tamanho em segundos do candle.
        private long timestamp;
        private float open;
        private float close;
        private float high;
        private float low;
        private float volume;
        private long endTimestamp;

        public Candle(int size, long timestamp, float open, float close, float high, float low, float volume)
        {
            this.size = size;
            this.low = low;
            this.open = open;
            this.close = close;
            this.high = high;
            this.volume = volume;
            this.timestamp = timestamp;
            endTimestamp = timestamp + size;
        }

        public int Size { get { return size; } set { size = value; } }
        public long Timestamp { get { return timestamp; } set { timestamp = value; } }
        public float Open { get { return open; } set { open = value; } }
        public float Close { get { return close; } set { close = value; } }
        public float High { get { return high; } set { high = value; } }
        public float Low { get { return low; } set { low = value; } }
        public float Volume { get { return volume; } set { volume = value; } }
        public long EndTimestamp { get { return endTimestamp; } set { endTimestamp = value; } }

        public DateTime DateTime {
            get {

                return  (new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).AddSeconds(timestamp);
            }
        }


    }
}
