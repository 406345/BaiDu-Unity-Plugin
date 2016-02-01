namespace baidu {
    public class AdSize {
        private int width;
        private int height;

        public static readonly AdSize Banner320x50 = new AdSize(320, 50);
        public static readonly AdSize Banner300x250 = new AdSize(300, 250);
        public static readonly AdSize Banner468x60 = new AdSize(468, 60);
        public static readonly AdSize Banner728x90 = new AdSize(728, 90);
        public static readonly AdSize Banner120x600 = new AdSize(120,600);
        

        public AdSize(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }
    }
}
