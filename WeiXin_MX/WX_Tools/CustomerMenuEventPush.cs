﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_Tools
{
    /// <summary>
    /// 自定义菜单事件推送
    /// </summary>
    public class CustomerMenuEventPush
    {

            #region 点击菜单拉取消息时的事件推送
            /*
             * 点击菜单拉取消息时的事件推送

                    推送XML数据包示例：
                    
                    <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[FromUser]]></FromUserName>
                    <CreateTime>123456789</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[CLICK]]></Event>
                    <EventKey><![CDATA[EVENTKEY]]></EventKey>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，CLICK
                    EventKey 	事件KEY值，与自定义菜单接口中KEY值对应
                    
             */
            #endregion

        
            #region 点击菜单跳转链接时的事件推送
            /*
             * 点击菜单跳转链接时的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml>
                    <ToUserName><![CDATA[toUser]]></ToUserName>
                    <FromUserName><![CDATA[FromUser]]></FromUserName>
                    <CreateTime>123456789</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[VIEW]]></Event>
                    <EventKey><![CDATA[www.qq.com]]></EventKey>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，VIEW
                    EventKey 	事件KEY值，设置的跳转URL
             */
            #endregion


            #region scancode_push：扫码推事件的事件推送
            /*
             *  scancode_push：扫码推事件的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
                    <FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
                    <CreateTime>1408090502</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[scancode_push]]></Event>
                    <EventKey><![CDATA[6]]></EventKey>
                    <ScanCodeInfo><ScanType><![CDATA[qrcode]]></ScanType>
                    <ScanResult><![CDATA[1]]></ScanResult>
                    </ScanCodeInfo>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间（整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，scancode_push
                    EventKey 	事件KEY值，由开发者在创建菜单时设定
                    ScanCodeInfo 	扫描信息
                    ScanType 	扫描类型，一般是qrcode
                    ScanResult 	扫描结果，即二维码对应的字符串信息
             */
            #endregion


            #region     scancode_waitmsg：扫码推事件且弹出“消息接收中”提示框的事件推送
            /*
             *  scancode_waitmsg：扫码推事件且弹出“消息接收中”提示框的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
                    <FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
                    <CreateTime>1408090606</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[scancode_waitmsg]]></Event>
                    <EventKey><![CDATA[6]]></EventKey>
                    <ScanCodeInfo><ScanType><![CDATA[qrcode]]></ScanType>
                    <ScanResult><![CDATA[2]]></ScanResult>
                    </ScanCodeInfo>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，scancode_waitmsg
                    EventKey 	事件KEY值，由开发者在创建菜单时设定
                    ScanCodeInfo 	扫描信息
                    ScanType 	扫描类型，一般是qrcode
                    ScanResult 	扫描结果，即二维码对应的字符串信息
             */
            #endregion

            #region  pic_sysphoto：弹出系统拍照发图的事件推送
            /*
             *  pic_sysphoto：弹出系统拍照发图的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
                    <FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
                    <CreateTime>1408090651</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[pic_sysphoto]]></Event>
                    <EventKey><![CDATA[6]]></EventKey>
                    <SendPicsInfo><Count>1</Count>
                    <PicList><item><PicMd5Sum><![CDATA[1b5f7c23b5bf75682a53e7b6d163e185]]></PicMd5Sum>
                    </item>
                    </PicList>
                    </SendPicsInfo>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，pic_sysphoto
                    EventKey 	事件KEY值，由开发者在创建菜单时设定
                    SendPicsInfo 	发送的图片信息
                    Count 	发送的图片数量
                    PicList 	图片列表
                    PicMd5Sum 	图片的MD5值，开发者若需要，可用于验证接收到图片
             */
            #endregion

            #region     pic_photo_or_album：弹出拍照或者相册发图的事件推送
            /*
             *  pic_photo_or_album：弹出拍照或者相册发图的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
                    <FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
                    <CreateTime>1408090816</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[pic_photo_or_album]]></Event>
                    <EventKey><![CDATA[6]]></EventKey>
                    <SendPicsInfo><Count>1</Count>
                    <PicList><item><PicMd5Sum><![CDATA[5a75aaca956d97be686719218f275c6b]]></PicMd5Sum>
                    </item>
                    </PicList>
                    </SendPicsInfo>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，pic_photo_or_album
                    EventKey 	事件KEY值，由开发者在创建菜单时设定
                    SendPicsInfo 	发送的图片信息
                    Count 	发送的图片数量
                    PicList 	图片列表
                    PicMd5Sum 	图片的MD5值，开发者若需要，可用于验证接收到图片
             */
            #endregion


            #region   pic_weixin：弹出微信相册发图器的事件推送
            /*
             * pic_weixin：弹出微信相册发图器的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
                    <FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
                    <CreateTime>1408090816</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[pic_weixin]]></Event>
                    <EventKey><![CDATA[6]]></EventKey>
                    <SendPicsInfo><Count>1</Count>
                    <PicList><item><PicMd5Sum><![CDATA[5a75aaca956d97be686719218f275c6b]]></PicMd5Sum>
                    </item>
                    </PicList>
                    </SendPicsInfo>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，pic_weixin
                    EventKey 	事件KEY值，由开发者在创建菜单时设定
                    SendPicsInfo 	发送的图片信息
                    Count 	发送的图片数量
                    PicList 	图片列表
                    PicMd5Sum 	图片的MD5值，开发者若需要，可用于验证接收到图片
             */
            #endregion

            #region location_select：弹出地理位置选择器的事件推送

            /*
             *  
                         
                    location_select：弹出地理位置选择器的事件推送
                    
                    推送XML数据包示例：
                    
                    <xml><ToUserName><![CDATA[gh_e136c6e50636]]></ToUserName>
                    <FromUserName><![CDATA[oMgHVjngRipVsoxg6TuX3vz6glDg]]></FromUserName>
                    <CreateTime>1408091189</CreateTime>
                    <MsgType><![CDATA[event]]></MsgType>
                    <Event><![CDATA[location_select]]></Event>
                    <EventKey><![CDATA[6]]></EventKey>
                    <SendLocationInfo><Location_X><![CDATA[23]]></Location_X>
                    <Location_Y><![CDATA[113]]></Location_Y>
                    <Scale><![CDATA[15]]></Scale>
                    <Label><![CDATA[ 广州市海珠区客村艺苑路 106号]]></Label>
                    <Poiname><![CDATA[]]></Poiname>
                    </SendLocationInfo>
                    </xml>
                    
                    参数说明：
                    参数 	描述
                    ToUserName 	开发者微信号
                    FromUserName 	发送方帐号（一个OpenID）
                    CreateTime 	消息创建时间 （整型）
                    MsgType 	消息类型，event
                    Event 	事件类型，location_select
                    EventKey 	事件KEY值，由开发者在创建菜单时设定
                    SendLocationInfo 	发送的位置信息
                    Location_X 	X坐标信息
                    Location_Y 	Y坐标信息
                    Scale 	精度，可理解为精度或者比例尺、越精细的话 scale越高
                    Label 	地理位置的字符串信息
                    Poiname 	朋友圈POI的名字，可能为空 
             */

            #endregion

        
    }
}
