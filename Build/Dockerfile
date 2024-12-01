FROM debian as freetypebuild
RUN apt-get update && apt-get upgrade -y
RUN apt-get install -y wget
RUN wget https://dl.google.com/android/repository/android-ndk-r27c-linux.zip
RUN wget https://download.savannah.gnu.org/releases/freetype/freetype-2.13.3.tar.xz
RUN apt-get install -y make
RUN apt-get install -y gcc
RUN apt-get install -y xz-utils
RUN apt-get install binutils
RUN apt-get install -y unzip
RUN unzip android-ndk-r27c-linux.zip
RUN tar -xf freetype-2.13.3.tar.xz
ENV NDK_PATH=/android-ndk-r27c
ENV HOST_PLATFORM=linux-x86_64
ENV TARGET_ARCH=x86_64
ENV API_LEVEL=34
ENV TOOLCHAIN=$NDK_PATH/toolchains/llvm/prebuilt/$HOST_PLATFORM
ENV SYSROOT=$TOOLCHAIN/sysroot
ENV PATH=$TOOLCHAIN/bin:$PATH
ENV CC=$TOOLCHAIN/bin/x86_64-linux-android$API_LEVEL-clang
ENV CXX=$TOOLCHAIN/bin/x86_64-linux-android$API_LEVEL-clang++
ENV AR=$TOOLCHAIN/bin/llvm-ar
ENV AS=$TOOLCHAIN/bin/llvm-as
ENV RANLIB=$TOOLCHAIN/bin/llvm-ranlib
ENV STRIP=$TOOLCHAIN/bin/llvm-strip
WORKDIR freetype-2.13.3
RUN ./configure --host=x86_64-linux-androideabi --prefix=$SYSROOT/usr --enable-shared
RUN make
CMD make install