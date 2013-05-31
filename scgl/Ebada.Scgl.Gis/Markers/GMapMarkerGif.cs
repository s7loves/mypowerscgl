using System;
using System.Collections.Generic;
using System.Text;
using GMap.NET.WindowsForms;
using System.Drawing;
using GMap.NET;
using System.Drawing.Imaging;

namespace Ebada.Scgl.Gis.Markers {
    /// <summary>
    /// 带动画标记,未完成
    /// </summary>
    [Serializable]
    internal class GMapMarkerGif : GMapMarkerVector {
        private Bitmap image;
        AnimateImage animate;
        public event EventHandler<EventArgs> OnFrameChanged;
        public Bitmap Image {
            get { return image; }
            set {
                image = value;
                animate = new AnimateImage(image);
                animate.OnFrameChanged += new EventHandler<EventArgs>(animate_OnFrameChanged);
                animate.Play();

            }
        }

        void animate_OnFrameChanged(object sender, EventArgs e) {
            if (OnFrameChanged != null)
                OnFrameChanged(sender, e);
        }
        public Bitmap ImageShadow;
        public GMapMarkerGif(PointLatLng p)
            : base(p) {
            Size = SizeSt = new Size(50, 50);
            Offset = new Point(-12, -12);
        }
        public override void OnRender(Graphics g) {
            if (Image != null) {
                lock (Image) {

                    g.DrawImage(Image, LocalPosition.X, LocalPosition.Y);
                }
            }
        }
    }
    /// <summary>   
    /// 表示一类带动画功能的图像。   
    /// </summary>   
    public class AnimateImage {
        Image image;
        FrameDimension frameDimension;
        /// <summary>   
        /// 动画当前帧发生改变时触发。   
        /// </summary>   
        public event EventHandler<EventArgs> OnFrameChanged;

        /// <summary>   
        /// 实例化一个AnimateImage。   
        /// </summary>   
        /// <param name="img">动画图片。</param>   
        public AnimateImage(Image img) {
            image = img;

            lock (image) {
                mCanAnimate = ImageAnimator.CanAnimate(image);
                if (mCanAnimate) {
                    Guid[] guid = image.FrameDimensionsList;
                    frameDimension = new FrameDimension(guid[0]);
                    mFrameCount = image.GetFrameCount(frameDimension);
                }
            }
        }

        bool mCanAnimate;
        int mFrameCount = 1, mCurrentFrame = 0;

        /// <summary>   
        /// 图片。   
        /// </summary>   
        public Image Image {
            get { return image; }
        }

        /// <summary>   
        /// 是否动画。   
        /// </summary>   
        public bool CanAnimate {
            get { return mCanAnimate; }
        }

        /// <summary>   
        /// 总帧数。   
        /// </summary>   
        public int FrameCount {
            get { return mFrameCount; }
        }

        /// <summary>   
        /// 播放的当前帧。   
        /// </summary>   
        public int CurrentFrame {
            get { return mCurrentFrame; }
        }

        /// <summary>   
        /// 播放这个动画。   
        /// </summary>   
        public void Play() {
            if (mCanAnimate) {
                lock (image) {
                    ImageAnimator.Animate(image, new EventHandler(FrameChanged));
                }
            }
        }

        /// <summary>   
        /// 停止播放。   
        /// </summary>   
        public void Stop() {
            if (mCanAnimate) {
                lock (image) {
                    ImageAnimator.StopAnimate(image, new EventHandler(FrameChanged));
                }
            }
        }

        /// <summary>   
        /// 重置动画，使之停止在第0帧位置上。   
        /// </summary>   
        public void Reset() {
            if (mCanAnimate) {
                ImageAnimator.StopAnimate(image, new EventHandler(FrameChanged));
                lock (image) {
                    image.SelectActiveFrame(frameDimension, 0);
                    mCurrentFrame = 0;
                }
            }
        }

        private void FrameChanged(object sender, EventArgs e) {
            mCurrentFrame = mCurrentFrame + 1 >= mFrameCount ? 0 : mCurrentFrame + 1;
            lock (image) {
                image.SelectActiveFrame(frameDimension, mCurrentFrame);
            }
            if (OnFrameChanged != null) {
                OnFrameChanged(image, e);
            }
        }
    }
}
