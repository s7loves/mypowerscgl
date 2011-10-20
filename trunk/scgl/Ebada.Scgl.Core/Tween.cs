using System;
using System.Collections.Generic;
using System.Text;

namespace Ebada.Scgl.Core {
    /// <summary>
//    Linear：无缓动效果；
//Quadratic：二次方的缓动（t^2）；
//Cubic：三次方的缓动（t^3）；
//Quartic：四次方的缓动（t^4）；
//Quintic：五次方的缓动（t^5）；
//Sinusoidal：正弦曲线的缓动（sin(t)）；
//Exponential：指数曲线的缓动（2^t）；
//Circular：圆形曲线的缓动（sqrt(1-t^2)）；
//Elastic：指数衰减的正弦曲线缓动；
//Back：超过范围的三次方缓动（(s+1)*t^3 - s*t^2）；
//Bounce：指数衰减的反弹缓动。
//ps：以上都是自己的烂翻译，希望各位修正。

//每个效果都分三个缓动方式（方法），分别是：
//easeIn：从0开始加速的缓动；
//easeOut：减速到0的缓动；
//easeInOut：前半段从0开始加速，后半段减速到0的缓动。
//其中Linear是无缓动效果，没有以上效果。


    /// </summary>
    public static class Easing {
        public enum Mode {
            linear,
            easeInQuad, easeOutQuad, easeInOutQuad,
            easeInCubic, easeOutCubic, easeInOutCubic,
            easeInQuart, easeOutQuart, easeInOutQuar,
            easeInQuint, easeOutQuint, easeInOutQuint,
            easeInSine, easeOutSine, easeInOutSine,
            easeInExpo, easeOutExpo, easeInOutExpo,
            easeInCirc, easeOutCirc, easeInOutCirc,
            easeInBounce, easeOutBounce, easeInOutBounce,
            easeInElastic, easeOutElastic, easeInOutElastic,
            easeInBack, easeOutBack, easeInOutBack,
            easeInStrong, easeOutStrong, easeInOutStrong
        }
        /// <summary>
        /// t: current time（当前时间）；
        //b: beginning value（初始值）；
        //c: change in value（变化量）；
        //d: duration（持续时间）。
        //ps：Elastic和Back有其他可选参数，里面都有说明。
        /// </summary>
        /// <param name="tick">当前时间</param>
        /// <param name="start">初始值</param>
        /// <param name="end">结束值</param>
        /// <param name="duration">持续时间</param>
        /// <param name="easingMode">变化类型</param>
        /// <returns></returns>
        public static float GetTween(int tick, float start, float end, float duration, Mode easingMode) {
            if (tick > duration) {
                return end;
            }

            float distance = end - start;

            switch (easingMode) {
                case Mode.linear: return linear(tick, start, distance, duration);

                case Mode.easeInQuad: return easeInQuad(tick, start, distance, duration);
                case Mode.easeOutQuad: return easeOutQuad(tick, start, distance, duration);
                case Mode.easeInOutQuad: return easeInOutQuad(tick, start, distance, duration);

                case Mode.easeInCubic: return easeInCubic(tick, start, distance, duration);
                case Mode.easeOutCubic: return easeOutCubic(tick, start, distance, duration);
                case Mode.easeInOutCubic: return easeInOutCubic(tick, start, distance, duration);

                case Mode.easeInQuart: return easeInQuart(tick, start, distance, duration);
                case Mode.easeOutQuart: return easeOutQuart(tick, start, distance, duration);
                case Mode.easeInOutQuar: return easeInOutQuar(tick, start, distance, duration);

                case Mode.easeInQuint: return easeInQuint(tick, start, distance, duration);
                case Mode.easeOutQuint: return easeOutQuint(tick, start, distance, duration);
                case Mode.easeInOutQuint: return easeInOutQuint(tick, start, distance, duration);

                case Mode.easeInSine: return easeInSine(tick, start, distance, duration);
                case Mode.easeOutSine: return easeOutSine(tick, start, distance, duration);
                case Mode.easeInOutSine: return easeInOutSine(tick, start, distance, duration);

                case Mode.easeInExpo: return easeInExpo(tick, start, distance, duration);
                case Mode.easeOutExpo: return easeOutExpo(tick, start, distance, duration);
                case Mode.easeInOutExpo: return easeInOutExpo(tick, start, distance, duration);

                case Mode.easeInCirc: return easeInCirc(tick, start, distance, duration);
                case Mode.easeOutCirc: return easeOutCirc(tick, start, distance, duration);
                case Mode.easeInOutCirc: return easeInOutCirc(tick, start, distance, duration);

                case Mode.easeInBounce: return easeInBounce(tick, start, distance, duration);
                case Mode.easeOutBounce: return easeOutBounce(tick, start, distance, duration);
                case Mode.easeInOutBounce: return easeInOutBounce(tick, start, distance, duration);

                case Mode.easeInElastic: return easeInElastic(tick, start, distance, duration);
                case Mode.easeOutElastic: return easeOutElastic(tick, start, distance, duration);
                case Mode.easeInOutElastic: return easeInOutElastic(tick, start, distance, duration);

                case Mode.easeInBack: return easeInBack(tick, start, distance, duration);
                case Mode.easeOutBack: return easeOutBack(tick, start, distance, duration);
                case Mode.easeInOutBack: return easeInOutBack(tick, start, distance, duration);

                case Mode.easeInStrong: return easeInStrong(tick, start, distance, duration);
                case Mode.easeOutStrong: return easeOutStrong(tick, start, distance, duration);
                case Mode.easeInOutStrong: return easeInOutStrong(tick, start, distance, duration);

                default: return 0;
            }
        }

        /*::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        :::::::::::::::::::::::::::::: easing mode below :::::::::::::::::::::::::::::::::
        ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::    */
        //=============== Linear ===========================================================
        private static float linear(float t, float b, float c, float d) {
            return -c * (t /= d) * (t - 2) + b;
        }

        //=============== Quad =============================================================
        private static float easeInQuad(float t, float b, float c, float d) {
            return c * (t /= d) * t + b;
        }
        private static float easeOutQuad(float t, float b, float c, float d) {
            return -c * (t /= d) * (t - 2) + b;
        }
        private static float easeInOutQuad(float t, float b, float c, float d) {
            if ((t /= d / 2) < 1) {
                return c / 2 * t * t + b;
            }
            return -c / 2 * ((-t) * (t - 2) - 1) + b;
        }

        //================ Cubic ==========================================================
        private static float easeInCubic(float t, float b, float c, float d) {
            return c * (float)Math.Pow(t / d, 3) + b;
        }
        private static float easeOutCubic(float t, float b, float c, float d) {
            return c * (float)(Math.Pow(t / d - 1, 3) + 1) + b;
        }
        private static float easeInOutCubic(float t, float b, float c, float d) {
            if ((t /= d / 2) < 1) {
                return c / 2 * (float)Math.Pow(t, 3) + b;
            }
            return c / 2 * (float)(Math.Pow(t - 2, 3) + 2) + b;
        }

        //================ Quart ==========================================================
        private static float easeInQuart(float t, float b, float c, float d) {
            return c * (float)Math.Pow(t / d, 4) + b;
        }
        private static float easeOutQuart(float t, float b, float c, float d) {
            return -c * (float)(Math.Pow(t / d - 1, 4) - 1) + b;
        }
        private static float easeInOutQuar(float t, float b, float c, float d) {
            if ((t /= d / 2) < 1) {
                return c / 2 * (float)Math.Pow(t, 4) + b;
            }
            return -c / 2 * (float)(Math.Pow(t - 2, 4) - 2) + b;
        }

        //================ Quint ==========================================================
        private static float easeInQuint(float t, float b, float c, float d) {
            return c * (float)Math.Pow(t / d, 5) + b;
        }
        private static float easeOutQuint(float t, float b, float c, float d) {
            return c * (float)(Math.Pow(t / d - 1, 5) + 1) + b;
        }
        private static float easeInOutQuint(float t, float b, float c, float d) {
            if ((t /= d / 2) < 1) {
                return c / 2 * (float)Math.Pow(t, 5) + b;
            }
            return c / 2 * (float)(Math.Pow(t - 2, 5) + 2) + b;
        }

        //================ Sine ===========================================================
        private static float easeInSine(float t, float b, float c, float d) {
            return c * (float)(1 - Math.Cos(t / d * (Math.PI / 2))) + b;
        }
        private static float easeOutSine(float t, float b, float c, float d) {
            return c * (float)Math.Sin(t / d * (Math.PI / 2)) + b;
        }
        private static float easeInOutSine(float t, float b, float c, float d) {
            return c / 2 * (float)(1 - Math.Cos(Math.PI * t / d)) + b;
        }

        //================ Expo ===========================================================
        private static float easeInExpo(float t, float b, float c, float d) {
            return c * (float)Math.Pow(2, 10 * (t / d - 1)) + b;
        }
        private static float easeOutExpo(float t, float b, float c, float d) {
            return c * (float)(-Math.Pow(2, -10 * t / d) + 1) + b;
        }
        private static float easeInOutExpo(float t, float b, float c, float d) {
            if ((t /= d / 2) < 1) {
                return c / 2 * (float)Math.Pow(2, 10 * (t - 1)) + b;
            }
            return c / 2 * (float)(-Math.Pow(2, -10 * -t) + 2) + b;
        }

        //================ Circ ===========================================================
        private static float easeInCirc(float t, float b, float c, float d) {
            return c * (1 - (float)Math.Sqrt(1 - (t /= d) * t)) + b;
        }
        private static float easeOutCirc(float t, float b, float c, float d) {
            return c * (float)Math.Sqrt(1 - (t = t / d - 1) * t) + b;
        }
        private static float easeInOutCirc(float t, float b, float c, float d) {
            if ((t /= d / 2) < 1) {
                return c / 2 * (1 - (float)Math.Sqrt(1 - t * t)) + b;
            }
            return c / 2 * ((float)Math.Sqrt(1 - (t -= 2) * t) + 1) + b;
        }

        //================ Bounce =========================================================
        private static float easeInBounce(float t, float b, float c, float d) {
            return c - easeOutBounce(d - t, 0, c, d) + b;
        }
        private static float easeOutBounce(float t, float b, float c, float d) {
            if ((t /= d) < (1 / 2.75)) {
                return (float)(c * (7.5625 * t * t) + b);
            } else if (t < (2 / 2.75)) {
                return c * (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f) + b;
            } else if (t < (2.5 / 2.75)) {
                return c * (7.5625f * (t -= (2.25f / 2.75f)) * t + 0.9375f) + b;
            } else {
                return c * (7.5625f * (t -= (2.625f / 2.75f)) * t + .984375f) + b;
            }
        }
        private static float easeInOutBounce(float t, float b, float c, float d) {
            if (t < d * 0.5) {
                return (easeInBounce(t * 2, 0, c, d) * 0.5f + b);
            }
            return (easeOutBounce(t * 2 - d, 0, c, d) * 0.5f + c * 0.5f + b);
        }

        //================ Elastic ========================================================
        private static float easeInElastic(float t, float b, float c, float d) {
            float s;
            float a = 0; float p = 0;
            if (t == 0) { return b; }
            if ((t /= d) == 1) { return b + c; }
            if (p == 0) { p = d * 0.3f; }
            if (a == 0 || (c > 0 && a < c) || (c < 0 && a < -c)) {
                a = c;
                s = p / 4;
            } else {
                s = p / (float)(Math.PI * 2 * Math.Asin(c / a));
            }
            return -(float)(a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * Math.PI * 2 / p)) + b;
        }
        private static float easeOutElastic(float t, float b, float c, float d) {
            float s; float a = 0; float p = 0;
            if (t == 0) { return b; }
            if ((t /= d) == 1) { return b + c; }
            if (p == 0) { p = d * 0.3f; }
            if (a == 0 || (c > 0 && a < c) || (c < 0 && a < -c)) {
                a = c;
                s = p / 4;
            } else {
                s = p / (float)(Math.PI * 2 * Math.Asin(c / a));
            }
            return (float)(a * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * Math.PI * 2 / p)) + c + b;

        }
        private static float easeInOutElastic(float t, float b, float c, float d) {
            float s; ; float a = 0; float p = 0;
            if (t == 0) { return b; }
            if ((t /= d * 0.5f) == 2) {
                return b + c;
            }
            if (p == 0) { p = d * (0.3f * 1.5f); }
            if (a == 0 || (c > 0 && a < c) || (c < 0 && a < -c)) {
                a = c;
                s = p / 4;
            } else {
                s = p / (float)(Math.PI * 2 * Math.Asin(c / a));
            }
            if (t < 1) {
                return -0.5f * (float)((a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * Math.PI * 2 / p))) + b;
            }
            return a * (float)(Math.Pow(2, -10 * (t -= 1)) * Math.Sin((t * d - s) * Math.PI * 2 / p)) * 0.5f + c + b;
        }

        //================ Back ===========================================================
        private static float easeInBack(float t, float b, float c, float d) {
            float s = 1.70158f;
            return c * (t /= d) * t * ((s + 1) * t - s) + b;
        }
        private static float easeOutBack(float t, float b, float c, float d) {
            float s = 1.70158f;
            return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
        }
        private static float easeInOutBack(float t, float b, float c, float d) {
            float s = 1.70158f;
            if ((t /= d * 0.5f) < 1) {
                return c * 0.5f * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
            }
            return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;
        }

        //================ Strong =========================================================
        private static float easeInStrong(float t, float b, float c, float d) {
            return c * (t /= d) * t * t * t * t + b;
        }
        private static float easeOutStrong(float t, float b, float c, float d) {
            return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
        }
        private static float easeInOutStrong(float t, float b, float c, float d) {
            if ((t /= d * 0.5f) < 1) {
                return c * 0.5f * t * t * t * t * t + b;
            }
            return c * 0.5f * ((t -= 2) * t * t * t * t + 2) + b;
        }
    }
}
